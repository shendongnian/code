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
