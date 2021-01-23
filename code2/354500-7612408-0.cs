    public class Foo
    {
      public string SrNo {get;set;}
      public string Date {get;set;}
      public string Time {get;set;}
      public string Symbol {get;set;}
    }
    
    List<Foo> list=new List<Foo>();
    
    while ((line = file.ReadLine()) != null)
    {
        string []ar = line.Split(',');
        list.Add(new Foo()
           {
             SrNo=ar[0],
             Date=ar[1],
             Time=ar[2],
             Symbol=ar[3]
           });
    }
    //Bind the list
    dataGridView1.DataSource=list;
