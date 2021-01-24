var tskJob = CreateTableAsync(sql, sqlcnn);   
tskJob.Wait() // Normally, you should use await if possible             
            using (frmUI ui = new frmUI())
            {
                // not needed Task.WhenAll(tskJob);
                ui.BindControl(
(...)
// Change Thread.Sleep(5000); // delay 5 seconds
//to
await Task.Delay(TimeSpan.FromSeconds(5));
