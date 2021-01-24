          public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
          
            FragmentTransaction transaction = this.FragmentManager.BeginTransaction();
        
            if (id == Resource.Id.nav_camera)
            {
                // Handle the camera action
                
            }
            else if (id == Resource.Id.nav_gallery)
            {
                fragment = new Fragment1();
             
            }
            else if (id == Resource.Id.nav_slideshow)
            {
                fragment = new Fragment2();
             
            }
            else if (id == Resource.Id.nav_manage)
            {
            }
            else if (id == Resource.Id.nav_share)
            {
            }
            else if (id == Resource.Id.nav_send)
            {
            }
           
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            transaction.Replace(Resource.Id.FramePage, fragment);
            transaction.Commit();
            return true;
        }
