      class Program
      {
        static void Main(string[] args)
        {
          PartNumber p1 = new PartNumber("BA-0001-3");
          for (int i = 0; i < 5; i++)
          {
            p1.Sub++;
            Debug.WriteLine(p1);
          }
    
          PartNumber p2 = new PartNumber("BA", 2, 3);
          for (int i = 0; i < 5; i++)
          {
            p2.Sub++;
            Debug.WriteLine(p2);
          }
    
        }
      }
    
      class PartNumber
      {
        public PartNumber(string make, int model, int sub)
        {
          Make = make;
          Model = model;
          Sub = sub;
        }
    
        public PartNumber(string part)
        {
          //Might want to validate the string here
          string [] fields = part.Split('-');
    
          //Are there 3 fields?  Are second and third fields valid ints?
          Make = fields[0];
          Model = Int32.Parse(fields[1]);
          Sub = Int32.Parse(fields[2]);
        }
    
        public string Make { get; set; }
        public int Model { get; set; }
        public int Sub { get; set; }
    
        public override string ToString()
        {
          return string.Format("{0}-{1:D4}-{2}", Make, Model, Sub);
        }
      }
