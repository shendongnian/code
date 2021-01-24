     private void ExtractData()
            {
                int moduleId;
                int marks;
                string name;
                foreach (DataRow row in custTable.Rows)
                {
                    name = row["Name"].ToString();
                    moduleId = 1;
                    marks = int.Parse(row["Module1Marks"].ToString());
                    NewInsertFunction(name, moduleId, marks);
    
                    moduleId = 2;
                    marks = int.Parse(row["Module2Marks"].ToString());
                    NewInsertFunction(name, moduleId, marks);
    
                    moduleId = 3;
                    marks = int.Parse(row["Module3Marks"].ToString());
                    NewInsertFunction(name, moduleId, marks);
                }
            }
            private void NewInsertFunction(string Name, int ModuleId, int Marks)
            {
                // Provide the Insert logic
            }
