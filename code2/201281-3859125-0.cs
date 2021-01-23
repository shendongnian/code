      class Program
      {
        static void Main(string[] args)
        {
          PartNumber p = new PartNumber("BA-0001-3");
          for (int i = 0; i < 5; i++)
          {
            p.Sub++;
            Debug.WriteLine(p);
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
          int firstDash = part.IndexOf('-');
          int secondDash = part.LastIndexOf('-');
    
          Make = part.Substring(0, firstDash);
          Model = Int32.Parse(part.Substring(firstDash+1, secondDash - firstDash - 1));
          Sub = Int32.Parse(part.Substring(secondDash+1));
        }
    
        public string Make { get; set; }
        public int Model { get; set; }
        public int Sub { get; set; }
    
        public override string ToString()
        {
          return string.Format("{0}-{1:D4}-{2}", Make, Model, Sub);
        }
      }
