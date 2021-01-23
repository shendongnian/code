    namespace StackOverflowWin.DataSet1TableAdapters
    {
    public partial class EmpTableAdapter
    {
        public void fillformyquery(StackOverflowWin.DataSet1.EmpDataTable emp1)
        {
            System.Data.OleDb.OleDbCommand[] mycol = new System.Data.OleDb.OleDbCommand[1];
            
            mycol[0] = new global::System.Data.OleDb.OleDbCommand();
            mycol[0].Connection = this.Connection;
            mycol[0].CommandText = "Select * from emp where name = '%alliswell%'";
            mycol[0].CommandType = global::System.Data.CommandType.Text;
            this._commandCollection  = mycol;
            //this._commandCollection = new System.Data.OleDb.OleDbCommand[1]; 
            this.Fill(emp1); 
        }
    }
     }
     //calling code
     public void RunMyQuery()
        {
            dataset1.EmpTableAdapter eda = new dataset1.EmpTableAdapter();//assume you have added adapter to the designeer
            dataset1.EmpDataTable emp1 = new dataset1.EmpDataTable();
             eda.fillformyquery(emp1);
            
        }
