var linkList = new LinkedList<int>(new int[] { 1, 2, 3, 4 }.AsEnumerable());
var first = linkList.First;
LinkedListNode<int> current = first;
while (true)
{
   
   Console.WriteLine($"Current value {current.Value}, press enter to Go Gext");
   Console.ReadLine();
   current = current.Next ?? first;
       
}
**Output:**
    Current value 1, press enter to Go Gext
    Current value 2, press enter to Go Gext
    Current value 3, press enter to Go Gext
    Current value 4, press enter to Go Gext
    Current value 1, press enter to Go Gext
    Current value 2, press enter to Go Gext
**WinForms** 
public LinkedList<object> linkList;
public LinkedListNode<object> current;
public LinkedListNode<object> first;
public Form1()
{
    InitializeComponent();
    linkList = new LinkedList<object>(new object[] { "A", "B", "C", "D" }.AsEnumerable());
    first = linkList.First;
    current = first;
    listBox1.Items.Add(current.Value);
}
private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
{
  
  current = current.Next ?? first;
  listBox1.Items.Add(current.Value);
    
}
**Output** 
[*GIF here*][1]
  [1]: https://i.stack.imgur.com/rPsts.gif
