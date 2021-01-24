            using (var context = new ParentDbContext())
            {
                var parent = context.Parents.Create();
                parent.Name = "Steve";
                parent.Daughters.Add(new Daughter { Name = "Elise" });
                parent.Daughters.Add(new Daughter { Name = "Susan" });
                parent.Sons.Add(new ASon { Name = "Jason" });
                parent.Sons.Add(new ASon { Name = "Duke" });
                context.Parents.Add(parent);
                context.SaveChanges();
            }
