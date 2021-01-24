        void NavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
                if (_global.tabSelected == e.Item.Order)
                {
                    switch (_viewPager.CurrentItem)
                    {
                        case 0:
                            _fm1.Pop2Root();
                            break;
                        case 1:
                            _fm2.Pop2Root();
                            break;
                        case 2:
                            _fm3.Pop2Root();
                            break;
                        case 3:
                            _fm4.Pop2Root();
                            break;
                        case 4:
                            _fm5.Pop2Root();
                            break;
                    }
                }
                else
                {
                    //_navigationView.SelectedItemId = e.Item.Order;
                    //_menu = _navigationView.Menu.GetItem(e2.Position);
                    //_navigationView.SelectedItemId = _menu.ItemId;
                    _viewPager.SetCurrentItem(e.Item.Order, true);
                }
            
        }
        private void ViewPager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            _menu = _navigationView.Menu.GetItem(e.Position);
            _navigationView.SelectedItemId = _menu.ItemId;
            _global.tabSelected = _viewPager.CurrentItem;
        }
