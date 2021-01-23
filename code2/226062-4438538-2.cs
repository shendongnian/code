    class Program {
        static void Main() {
            var add = new WhateverAddIs {
                Documents = {
                    new Document {
                        Fields = {
                            new Field { Name="id", Value ="1"},
                            new Field { Name="Myname", Value ="Myname1"},
                        }                        
                    }, new Document {
                        Fields = {
                            new Field { Name="id", Value ="2"},
                            new Field { Name="Myname", Value ="Myname2"},
                        }
                    }, new Document {
                        Fields = {
                            new Field { Name="id", Value ="3"},
                            new Field { Name="Myname", Value ="Myname3"},
                        }
                    }
                }
            };
            var ser = new XmlSerializer(add.GetType());
            ser.Serialize(Console.Out, add);
        }
    }
