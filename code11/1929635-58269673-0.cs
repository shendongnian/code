public class TextAdapter : BaseAdapter
{
  Context context;
  List<string> Sources;
  public TextAdapter(Context c , List<string> s)
  {
    context = c;
    Sources = s;
  }
  public override int Count
  {
     get { return Sources.Count; }
  }
  public override Java.Lang.Object GetItem(int position)
  {
     return null;
  }
  public override long GetItemId(int position)
  {
     return 0;
  }
  // create a new ImageView for each item referenced by the Adapter
  public override View GetView(int position, View convertView, ViewGroup parent)
  {
     TextView textView;
     if (convertView == null)
     {
       textView =new TextView(context);
       textView.SetLines(1);
     }
     else
     {
        textView = (TextView)convertView;
     }
     textView.SetText(Sources[position],null);
            
     return textView;
  }
  
}
And set the **Adapter** in Activity
gridview.Adapter = new TextAdapter(this,comanda);
