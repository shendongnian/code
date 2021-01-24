 class PosHolder
    {
        public int pos { get; set; }
    }
And in MainActivity
PosHolder _pos = new PosHolder();
I passed both my chosen function as lambda expression and _pos into my adapter constructor
SpiceListAdapter _adapter = new SpiceListAdapter(this, spices, () => { MyFunction(); }, _pos);
In my adapter class I create an Action, added a click listener to my root axml layout node. This click event changes the value of _pos to "position" then uses the click.Invoke() method to call the function passed into the constructor. 
//create action
public Action Click { get; set; }
// Adapter Constructor
public SpiceListAdapter(Context context, List<Spice> names, Action click, PosHolder Pos)
        {
            mItems = names;
            mContext = context;
            Click = click;
            mPos = Pos;
            mCupboard = cupboard;
            mShopList = shoppingList;
        }
//Click event
SpiceRowItem.Click += delegate
            {
                mPos.pos = position;
                Click?.Invoke();
            };
I'ts probably far from best practice but it works for me and sorted my issue out.
Hope it helps.
