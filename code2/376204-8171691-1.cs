       public void update()
       {
          this.list.Items.Clear();
          this.list.Update(); // In case there is databinding
          this.list.Refresh(); // Redraw items
       }
