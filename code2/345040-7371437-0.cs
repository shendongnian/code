        protected override void OnDragEnter(DragEventArgs drgevent) {
            var obj = drgevent.Data.GetData(drgevent.Data.GetFormats()[0]);
            if (typeof(Base).IsAssignableFrom(obj.GetType())) {
                drgevent.Effect = DragDropEffects.Copy;
            }
        }
