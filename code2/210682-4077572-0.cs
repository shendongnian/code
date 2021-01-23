    char[] charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
     
    private void button1_Click(object sender, EventArgs e)
            {
                List<String> MyList = new List<string>();
                int n = 390;
                //limit range from A-Z (n=26)
                if (n <= 26)  FillSingle(MyList);
                
                //limit range from A - ZZ (n= 702)
                if (n > 26)
                {
                    FillSingle(MyList);
                    FillDouble(MyList);
                }
                //limit range from A - ZZZ (n > 702)
                if (n > 702)
                {
                    FillSingle(MyList);
                    FillDouble(MyList);
                    FillTriple(MyList);
                }
    
                MyList = MyList.Take(n).ToList<string>();
            }
    
    //Methods
    
     private void FillSingle(List<string> MyList)
            {           
                charArray.ToList().ForEach(i=>MyList.Add(i.ToString()));
            }
    
            //two times  cross product
            private void FillDouble(List<string> MyList)
            {
                (from dbl1 in charArray
                 from dbl2 in charArray
    
                 select new
                 {
                     dblString = dbl1.ToString() + dbl2.ToString()
                 }).ToList().ForEach(i => MyList.Add(i.dblString));
            }
    
            //3 times cross product
            private void FillTriple(List<string> MyList)
            {
                (from tpl1 in charArray
                 from tpl2 in charArray
                 from tpl3 in charArray
    
                 select new
                 {
                     tplString = tpl1.ToString() + tpl2.ToString() + tpl3.ToString()
                 }).ToList().ForEach(i => MyList.Add(i.tplString));
            }
