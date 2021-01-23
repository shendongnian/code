        public override string ToString()
        {
            return string.Join(Environment.NewLine, 
              GetType().GetProperties().Select( 
                 item => item.Name + ": " + (item.GetValue(this, null) ?? string.Empty).ToString()
                 ));
        }
