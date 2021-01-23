      protected overrides CreateChildControls()
      {
           foreach (string item in this.Items)
           {
                Passanger p = new Passenger();
                p.Something = item;
                this.p_passengers.Controls.Add(p);
           }
      }
