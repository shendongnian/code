     FragmentTransaction fTransaction = FragmentManager.BeginTransaction();
                hideAllFragment(fTransaction);
                //judge which tab is clicked
                switch (tab.Id)
                {
                    case Recent:                
                        if (recentFragment== null)
                        {
                            recentFragment= new RecentFragment ();
                            fTransaction.Add(Resource.Id.ly_content, recentFragment);
                        }
                        else{fTransaction.Show(recentFragment);}break;
                    case Favorite:
                        if (favoriteFragment== null)
                        {
                            favoriteFragment= new FavoriteFragment();
                            fTransaction.Add(Resource.Id.ly_content, favoriteFragment);
                        }
                        else{fTransaction.Show(favoriteFragment);}
                        break;
                    case NearBy:
                        if (nearByFragment== null)
                        {
                            nearByFragment= new NearByFragment();
                            fTransaction.Add(Resource.Id.ly_content, nearByFragment);
                        }else{fTransaction.Show(nearByFragment);}break;
                }
                fTransaction.Commit();
