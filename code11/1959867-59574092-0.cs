    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            ShellSection shell_section = new ShellSection
            {
                Title = "home",
            };
            shell_section.Items.Add(new ShellContent() { Content = new ItemsPage() });
            ShellSection shell_section1 = new ShellSection
            {
                Title = "about",
            };
            shell_section1.Items.Add(new ShellContent() { Content = new AboutPage() });
            myshell.Items.Add(shell_section);
            myshell.Items.Add(shell_section1);
        }
    }
