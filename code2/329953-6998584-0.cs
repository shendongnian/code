        private void PhotoChooserCompleted(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                var img = new BitmapImage();
                img.SetSource(e.ChosenPhoto);
            }
        }
