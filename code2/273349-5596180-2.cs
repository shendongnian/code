        [XmlAttribute]
        public string DataTableName { get; set; }
        public TaskListClass TaskList { get; set; }
        public override void Execute(WorkContainer container)
        {
            int iteration = 0;
            string originalTaskName=String.Empty;
            // Log Start
            base.Execute(container);
            // Get the Data Table Based upon the ContainerKey
            DataTable loopTable = container.GetKeyValue<DataTable>(DataTableName);
            // If not found throw exception and exit
            if (loopTable == null)
            {
                throw new ArgumentException(
                    "DataTable Not Found or Initialized For Loop Variable",
                    DataTableName);
            }
            // For each row returned run the task in order as a mini-process
            foreach (DataRow row in loopTable.Rows)
            {
                iteration++;
                foreach (TaskBase task in TaskList.Tasks)
                {
                    // If it is the first iteration then create a new string with the iteration number
                    // else just replace the last iteration number with the current iteration number
                    if (iteration == 1)
                    {
                        task.Name = String.Format("Iteration {0} - {1}", iteration, task.Name);
                    }
                    else
                    {
                        task.Name = task.Name.Replace(String.Format("Iteration {0}",iteration-1),String.Format("Iteration {0}",iteration));
                    }
                    // Call the task Constructor to Initialize the object
                    task.GetType().GetConstructor(new Type[0]).Invoke(null);
                    foreach (DataColumn dc in loopTable.Columns)
                    {
                        // Store in Stack Variable
                        string propertyName = dc.ColumnName;
                        
                        // If a field in the table matches a 
                        // property Name set that property
                        PropertyInfo propInfo = task.GetType().GetProperty(propertyName);
                        if (propInfo != null)
                        {
                            propInfo.SetValue(task, row[dc], null);
                        }                        
                        else
                        {
                            // Else if the task has a Parameters collection add the 
                            // name of the column and value to the Parameter Collection
                            propInfo = task.GetType().GetProperty("Parameters");
                            if (propInfo != null)
                            {
                                List<Parameter> parameters = propInfo.GetValue(task, null) as List<Parameter>;
                                // If the parameter Name already Exist then Override it
                                // This means that the values in the DataTable override the values in the XML
                                if (parameters.Contains(new Parameter { Name = propertyName }))
                                {
                                    parameters.Remove(new Parameter { Name = propertyName });
                                }
                                parameters.Add(new Parameter { Name = propertyName, Value = row[dc].ToString(), Type="String" });
                            }
                            else
                            {
                                ParameterNotFoundException pExp = new ParameterNotFoundException(propertyName, task.GetType().ToString());
                                throw new TaskException("Unable to assign a Parameter", pExp.Message, pExp);
                            }
                        }
                    }
                    task.Execute(container);
                }
            }
            base.Finish(container);
        }
