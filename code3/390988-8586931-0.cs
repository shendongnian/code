    class Crs:IEquatable<Crs>
            {
                public int Id { get; set; }
                public string Description { get; set; }
    
                public bool Equals(Crs other)
                {
                    if (Object.ReferenceEquals(other, null)) 
                        return false;
    
                    if (Object.ReferenceEquals(this, other)) 
                        return true;
    
                    return Id.Equals(other.Id) && Description.Equals(other.Description);
                }
    
                public override int GetHashCode()
                {
                    int hashId = Id.GetHashCode();
                    int hashDescription = Description == null ? 0 : Description.GetHashCode();
                    return hashId ^ hashDescription;
                }
    
            }
    
            internal static void RunMe()
            {
                var dataTable = new List<Crs>(){
                    new Crs{Id=1, Description="First"},
                    new Crs{Id=2, Description="Second"},
                    new Crs{Id=5, Description="Fifth"}
                };
    
                var enumerable = new List<Crs>(){
                    new Crs{Id=2, Description="Second"},
                    new Crs{Id=4, Description="Fourth"}
                };
    
                var distinct = dataTable.Except(enumerable);
    
                distinct.ToList().ForEach(d => Console.WriteLine("{0}: {1}", d.Id, d.Description));
            }
