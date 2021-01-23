    class person1
                {
                    public int x, y;
                    public person1(int x,int y)
                        {
                        this.x = x;
                        this.y = y;
        
                        }
                    public void changes(person1 p1)
                    {
                       // int t;
                        this.x = x + y;  //x=30 x=10,y=20
                        this.y = x - y;  //y=30-20=10
                        this.x = x - y; //x=30-10=20
                    }
        }
         static void Main(string[] args)
           {
                 person1 p1 = new person1(10,20);
                 p1.changes(p1);
                 Console.WriteLine("swapp hoge kya ?x={0} and y={1}", p1.x, p1.y);
                 Console.ReadKey();
          }
