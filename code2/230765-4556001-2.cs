            XElement xml = XElement.Load(@"c:\myXml.xml");
            using (var context = new MyDataContext(connectionStr))
            {
                var entity = new MyTable{XML = xml};
                context.MyTables.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
