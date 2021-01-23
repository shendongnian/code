        public void Flip()
        {
            if (!Reversed)
            {
                Storyboard sbFlip = Resources["sbFlip"] as Storyboard;
                sbFlip.Begin();
                Reversed = true;
            }
            else
            {
                Reversed = false;
                Storyboard sbReverse = Resources["sbReverse"] as Storyboard;
                sbReverse.Begin();
            }
        }
