    public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.nav_rego)
            {
                var fragment = SpinnerFragment.NewInstance();
                //var fragmentManager = FragmentManager;
                var fragmentManager = SupportFragmentManager;
                var ft = fragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.LLTarget, fragment);
                ft.Commit();
                                
            }
       }
