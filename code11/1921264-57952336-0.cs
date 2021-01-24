public void RemoveItem(int position)
{
  ArrayList al = new ArrayList(MainActivity.mEmails);
  al.RemoveAt(position);
  NotifyDataSetChanged();
  NotifyItemChanged(position);
}
You create a new array `al` .But you should remove the item from the ItemsSource of Recyclerview .
public void RemoveItem(int position)
{
  mEmails.RemoveAt(position);
  NotifyDataSetChanged();
  NotifyItemChanged(position);
}
