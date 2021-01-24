    static class MyNavigate
        {​
            public static void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)​
            {​
                Frame currentFrame = sender.Content as Frame;​
                String name = currentFrame.Name;​
                if (name == "OtherFrame")​
                {​
                    currentFrame.Navigate(.......);​
                }​
                else {​
                    currentFrame.Navigate(.......);​
                }​
            }​
        }
