    public static List<DropdownModel> GetTypesBySubTypes(List<string> ListSubTypes)
        {
            List<DropdownModel> Types = new List<DropdownModel>();
            List<int> subTypes = ListSubTypes.Select(s => int.Parse(s)).ToList();
            using (DocumentXtractorEntities DataBase = new DocumentXtractorEntities())
            {
                    Types.AddRange((from C in DataBase.Type
                                   .Where(s => s.Active 
                                           && subTypes.Intersect(s.SubType.Select(st => st.SubTypesID)).Any())
                                    select new DropdownModel()
                                    {
                                        ID = C.TypeID,
                                        Description = C.Name,
                                    }).ToList());
                
            }
            return Types;
        }
