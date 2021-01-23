    public class MyPageClass {
        private void DisplayCustomers() {
            GridView.DataSource = SystemFacade.GetCustomers();
        }
    }
