    private void MyUIElement_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //find the clicked row
            var tempObject = e.Source as [whatever];
            if (tempObject == null) return;
            DragDrop.DoDragDrop(tempObject, tempObject.PropertyToBePassed, DragDropEffects.Copy);
        }
