    Dictionary<string,int> dic=new Dictionary<string,int>();
                dic.Add("red", 5);
                dic.Add("black", 10);
                dic.Add("white", 1);
                object[] obj;
                foreach(var o in dic)
                {
                    var sam= new { color = o.Key,value=o.Value };
                    Console.WriteLine(sam.color);               
    
                }
