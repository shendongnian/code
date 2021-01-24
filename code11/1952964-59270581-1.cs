Button _lastButton;
private void button1_Click_7(object sender, EventArgs e)
{            
     ...
     _lastButton=btn;
     Controls.Add(btn);
     ...
}
private void deletebutton_Click(object sender, EventArgs e)
{
     if(_lastButton!=null)
     {
         Controls.Remove(_lastButton);
     }
}
If you want to be able to delete multiple buttons from last to first, create a Stack<Button> field and push the buttons to it. When you want to delete one, Pop it and delete it
Stack<Button> _buttons=new Stack<Button>;
private void button1_Click_7(object sender, EventArgs e)
{            
     ...
     _buttons.Push(btn);
     Controls.Add(btn);
     ...
}
private void deletebutton_Click(object sender, EventArgs e)
{
     if(_buttons.TryPop(out var btn)
     {
         Controls.Remove(btn);
     }
}
**Update**
The code above is just for demonstration purposes. Removing the button from the `Controls` collection isn't enough. The *event handlers* have to be removed too, and finally, the button must be disposed. Otherwise the code will leak delegates and GDI handles. 
Instead of using a lambda, `Click`'s event handler must become a separate method, eg :
void SpawnOnClick(object sender, EventArgs args) 
{
    Process.Start(websitetextbox.Text);        
};
private void button1_Click_7(object sender, EventArgs e)
{            
     ...
     Controls.Add(btn);
     btn.Click+=SpawnOnClick;
     _buttons.Push(btn);
     ...
}
private void deletebutton_Click(object sender, EventArgs e)
{
     if(_buttons.TryPop(out var btn)
     {
         Controls.Remove(btn);
         btn.Click-=SpawnOnClick;
         btn.Dispose();
     }
}
