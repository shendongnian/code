public class Point
{
   public string Header{get;set;}
   public string Tx {get;set;}
   public string Rx  {get;set;}
   Public Point(string header,string tx,string rx)
   {
       Header=header;
       Tx=tx;
       Rx=rx;
   }
}
Your code remain the same of creating the objects and adding it to list.
From your Pseudo-Code, update this to -
foreach(var pt in _pList)
{
string header= "something";
string tx = "tx1";
string rx = "rx1";
if(pt.Header==header && pt.Tx==tx && pt.Rx==rx) // just a Pseudo-Code
{
// some tasks
}
Above is simple change you can make to your code.
 
