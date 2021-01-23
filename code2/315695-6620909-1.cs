     public void GenerateResx()
        {
            Type model = typeof(BuyCABModel);
            List<Type> member = new List<Type>();
            member.Add(typeof(RegisterModel));
            member.Add(typeof(AddOpenAuthAccountModel));
            member.Add(typeof(LoginModel));
            CreateRes(member, "Views.Member.resx");
        }
        private void CreateRes(List<Type> models, string resxFile)
        {
            using (ResXResourceWriter writer = new ResXResourceWriter("c:\\temp\\"+resxFile))
            {
                foreach(Type model in models) 
                {
                    PropertyInfo[] ps= model.GetProperties();
                    foreach (PropertyInfo p in ps)
                    {
                        foreach (Attribute a in p.GetCustomAttributes(true))
                        {
                            if (a.GetType() == typeof(DisplayNameAttribute))
                            {
                                DisplayNameAttribute d = (DisplayNameAttribute)a;
                                writer.AddResource(p.Name + "_DisplayName", d.DisplayName);
                            }
                            else if (a.GetType() == typeof(DisplayAttribute))
                            {
                                DisplayAttribute d = (DisplayAttribute)a;
                                writer.AddResource(p.Name + "_DisplayName", d.Name);
                            }
                        }
                    }
                }
                writer.Generate();
                writer.Close();
            }
        }
