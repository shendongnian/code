    using (ClientContext context = new ClientContext("http://sp"))
                {
                    var web = context.Web;
                    var myList = web.Lists.GetByTitle("Test");
                    var field = myList.Fields.GetByTitle("Options");
                    context.Load(field);
                    context.ExecuteQuery();
                    FieldChoice choiceField = context.CastTo<FieldChoice>(field);
                    foreach (string choice in choiceField.Choices)
                    {
                        comboBox1.Items.Add(choice);
                    }
    
                }
