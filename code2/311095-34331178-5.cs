    private void MenuPanel_OnTap(object sender, GestureEventArgs e)
            {
                Storyboard sb = App.Current.Resources["ShowMenuAnimationKey"] as Storyboard;
                sb.Stop();
                Storyboard.SetTarget(sb, ViewPanel);
                sb.Begin();
            }
