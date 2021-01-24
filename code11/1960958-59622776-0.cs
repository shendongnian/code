private async Task StartTimer() {
    _timerEnabled = true; 
    int i = 0;
    while (_timerEnabled) { 
        i++;
        if (i > 2) { i = 0; }
        pictureBox2.Image =  imageList1.Images[i];
        pictureBox1.Refresh();
        pictureBox2.Refresh(); 
        await Task.Delay(3000); 
    } 
}
