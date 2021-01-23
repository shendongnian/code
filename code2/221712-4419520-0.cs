     lbDragDrop.DragOver += (src, e) =>
          {
              VaultSocketViewModel vm = this.DataContext as VaultSocketViewModel;
              ListBoxDragDropTarget target = src as ListBoxDragDropTarget;
              ObservableCollection<ItemModel> listBoxBinding = vm.Slots[target.Name];
              object data = e.Data.GetData(e.Data.GetFormats()[0]);
              ItemDragEventArgs eventArgs = data as ItemDragEventArgs;
              SelectionCollection coll = eventArgs.Data as SelectionCollection;
              ItemModel newItem = coll.Select(t => t.Item).OfType<ItemModel>().FirstOrDefault();
              if (!target.Name.StartsWith(newItem.ItemSlot))  // don't allow drop
              {
                  e.Effects = Microsoft.Windows.DragDropEffects.None;
                  e.Handled = true;
              }
              else
              {
              }
          };
