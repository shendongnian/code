using(var connection = new SqlConnection(...))
  sql = "insert into sales(subtoal,pay,bal) values(@subtoal,@pay,@bal); select scope_identity();";
  var lastInsertId = connection.Query<int>(sql, new { 
     subtoal = txtSub.Text,
     pay = textBox1.Text,
     bal = txtBal.Text
   }
  ).Single();
  foreach(...)
}
It does all the parameter jiggling for you, runs the query, manages the connection  ,returns a type casted int etc
Also if your datagridview is based on a DataTable (and even better a strongly typed datatable) you can use it in your foreach. Here's what a strongly typed table would look like:
using(...){
  foreach(var ro in SalesProductTable){
    sql = "insert into sales_product(sales_id,prodname,price,qty,total) values(@sales_id,@prodname,@price,@qty,@total)";
    dapperConnection.Execute(sql, new { ro.sales_id, ro.prodname, ro.price, ro.qty, ro.total });
  }
Yep, that's it; just 4 lines of code, and it's easier if your @param names match  your column names in your strongly typed table. 
I think you might even just  be able to get Dapper to do the looping too, by passing the datatable in, so long as the rows have properties that are the same as the parameters in the query:
using(...){
    sql = "insert into sales_product(sales_id,prodname,price,qty,total) values(@sales_id,@prodname,@price,@qty,@total)";
    dapperConnection.Execute(sql, salesProductTable);
}
take a look - http://dapper-tutorial.net
