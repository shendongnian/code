    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity,BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private BottomNavigationView mBottomNavigationView;
        private int lastIndex;
        List<Android.Support.V4.App.Fragment> mFragments;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            initBottomNavigation();
            initFragments();
           
        }
        // Initialize the fragments
        public void initFragments()
        {
            mFragments = new List<Android.Support.V4.App.Fragment>();
            mFragments.Add(new ContactsFragment());
            mFragments.Add(new DiscoverFragment());
            mFragments.Add(new AccountFragment());
            // Initialization display ContactsFragment
            setFragmentPosition(0);
        
        }
        public void initBottomNavigation()
        {
            mBottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bv_bottomNavigation);
            mBottomNavigationView.SetOnNavigationItemSelectedListener(this);
    }
       //Show the corresponding fragment according to positon and hide the previous fragment
       private void setFragmentPosition(int position)
        {
          FragmentTransaction ft = SupportFragmentManager.BeginTransaction();
          Android.Support.V4.App.Fragment currentFragment = mFragments[position];
          Android.Support.V4.App.Fragment lastFragment = mFragments[lastIndex];
          lastIndex = position;
          ft.Hide(lastFragment);
          if (!currentFragment.IsAdded)
           {
            SupportFragmentManager.BeginTransaction().Remove(currentFragment).Commit();
            ft.Add(Resource.Id.ll_frameLayout, currentFragment);
           }
          ft.Show(currentFragment);
          ft.CommitAllowingStateLoss();
        }
        //Listen for Tab select by MenuItem's id
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_contacts:
                    setFragmentPosition(0);
                    break;
                case Resource.Id.menu_discover:
                    setFragmentPosition(1);
                    break;
                case Resource.Id.menu_me:
                    setFragmentPosition(2);
                    break;
                default:
                    break;
            }
            // Return true, otherwise click invalid
            return true;
        }
    }
