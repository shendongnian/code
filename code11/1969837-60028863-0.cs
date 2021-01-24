private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            Module module = (Module) ((Button) e.Source).DataContext;
            if (ChosenMods.Contains(module))
            {
                try
                {
                    MessageBox.Show("The Module `" + module.Name + "` is already chosen!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    ChosenMods.Add(module);
                    MessageBox.Show("The Module `" + module.Name + "` has been added!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
I basically get the Datacontext of the Button with the `Module module = (Module) ((Button) e.Source).DataContext;`
I later to put it inside a List of Modules, which i reuse later.
The first problem was the initialization of my List which looked like this:
public List<Module> ChosenMods { get; set; }
but had to look like this:
public List<Module> ChosenMods = new List<Module>();
public List<Module> ChosenMods1
        {
            get => ChosenMods;
            set => ChosenMods = value;
        }
The second problem was, that i used DataRowView which, i realized, was absolutely pointless there.
Thanks for your answers anyway, have a nice Week.
Greetings, IRezzet
