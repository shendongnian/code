    public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
          // Let the control handle the keys listed.
          switch (keyData & Keys.KeyCode)
          {
            case Keys.Left:
            case Keys.Up:
            case Keys.Down:
            case Keys.Right:
            case Keys.Home:
            case Keys.End:
            case Keys.PageDown:
            case Keys.PageUp:
              return true;
            default:
             // return false; <--not this
             return !dataGridViewWantsInputKey; //try this!
          }
        }
