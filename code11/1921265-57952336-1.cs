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
###Update 
Improve your code as follow 
###in SwipeToDeleteCallback
private RecyclerAdapter mdapter;
public SwipeToDeleteCallback(int dragDirs, int swipeDirs, Context context, RecyclerAdapter mRecyclerView , List<Email> mails) : this(dragDirs, swipeDirs, context)
{
   this.context = context;
   this.mdapter = mRecyclerView;
   deleteIcon = ContextCompat.GetDrawable(context, Resource.Drawable.alter_delete);
   intrinsicWidth = deleteIcon.IntrinsicWidth;
   intrinsicHeight = deleteIcon.IntrinsicHeight;
   background = new Android.Graphics.Drawables.ColorDrawable();
   backgroundColor = Color.ParseColor("#f44336");
   clearPaint = new Paint();
   mEmails = mails;
   clearPaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));
}
public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
{
   //Invoke Removing Item method from 
          
   mdapter.RemoveItem(viewHolder.AdapterPosition);
}
### in RecyclerAdapter.cs
public void RemoveItem(int position)
{
   mEmails.RemoveAt(position);
   NotifyDataSetChanged();
   NotifyItemChanged(position);
}
###in MainActivity
RecyclerAdapter mAdapter = new RecyclerAdapter(mEmails, this);
mRecyclerView.SetAdapter(mAdapter);
var swipeHandler = new SwipeToDeleteCallback(0, ItemTouchHelper.Left, this, mAdapter,mEmails);
var itemTouchHelper = new ItemTouchHelper(swipeHandler);
itemTouchHelper.AttachToRecyclerView(mRecyclerView);
