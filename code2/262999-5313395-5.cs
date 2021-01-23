        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                IsDropDownOpen = !IsDropDownOpen;
                e.Handled = true;
            }
            else if (IsDropDownOpen)
            {
                if (e.Key>=Key.A && e.Key<= Key.Z) //make it better!
                {
                    var ch = (char)((int)(e.Key-Key.A) + 0x41); //awful!!!
                    this._textSought += ch;
                    this._timer.Stop();
                    this._timer.Start();
                    for (int i = 0, count = this.Items.Count; i < count; i++)
                    {
                        var text = string.Format("{0}", this.Items[i]);
                        if (text.StartsWith(this._textSought, StringComparison.InvariantCultureIgnoreCase))
                        {
                            ListBoxItem listBoxItem = (ListBoxItem)this.ItemContainerGenerator.ContainerFromIndex(i);
                            var scroller = (ScrollViewer)this.GetTemplateChild("PART_Scroller"); //move out in OnApplyTemplate
                            scroller.ScrollToVerticalOffset(i);
                            this.ScrollIntoView(listBoxItem);
                            break;
                        }
                    }
                }
            }
            else
                base.OnKeyDown(e);
        }
