    public class Form...
    {
       private int elemsCount = 0;
       public event(...)
       {
          MyDatabase mydata = new MyDatabase();
          List<MyDatabase> listmydata = new List<MyDatabase>();
          
          mydata.id = elemsCount.ToString();
          mydata.Name = "YO";
          mydata.ActiveStatus= true;
          listmydata.Add(mydata);
          dataGridView1.DataSource = listmydata.ToList<MyDatabase>();
          elemsCount++;
       }
    }
