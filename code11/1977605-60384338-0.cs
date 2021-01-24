cs
private void btnAddMore_Click(object sender, RoutedEventArgs e) {
    Button newBtn = new Button {Content = "A New Button"};
    splMain.Children.Add(newBtn); // button is added
    _yee.discover((o, args) => {
        BeginInvoke((Action)(() => {
            Button newBtn2 = new Button {Content = args.Device.Hostname.ToString()};
            splMain.Children.Add(newBtn2); // NO button is added
        }));
    });
}
Additionally you should take care that an event handler will never throw an exception; you might not know how the code raising the event will cope with it.
