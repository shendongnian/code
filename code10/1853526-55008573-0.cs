using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
/* QUICK TERMINOLOGY
    List = An Array that constantly adjusts its maximum size
    names = Our actual "database" or table with our values that we've inputted
    List_Box = The display table that is visible on the program itself
    var = Variable... You know...
    "public" or "private" = Those define whether the function is visible to the rest of the program or other "sheets" in the program
    void = Defines whether the return value or the output of a function should be something, void means not specified, 
            if you want string you put string, if you want an integer you put int... etc etc.
*/
namespace ArrayApp
{
    public partial class MainWindow : Window
    {
        /* Private Function for Creating the List which will be a String
        We are using a List instead of an Array as an Array needs 
        a specific amount of indexes so if we have a specific number of data or 
        a maximum amount of data that a user can input then array would be used
        but since we don't know how many indexes we need a list will automatically
        adjust the maximum size of our table to suit our needs. I.e. limitless  */
        private List<string> names;
        public MainWindow()
        {
            InitializeComponent();
            names = new List<string>();
        }
        /* Class for our Items in our list this is not referring the list above but...
        the list that it displays as we have a search on demand
        but also allows us to search for specific people in the List (array/table) rather than
        display over 100+ people, if our database was to get to that size.
        
        Our class function defines what data can be put into our Display List ( List_Box ) 
        Therefore the index can only be an integer and name can only be a string
        more on this later.  */
        class Items
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }
        /* The Add Button Function
        This button takes the content of the TextBox that is right next to it and 
        adds it to our list called "names" but does not update our display, instead
        it shows us a message stating that the value was added to the list.
        If we were using an Array with a limited size, we could use an IF to check
        if there is a space available and output a message saying "Full" or "Failed"  */
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            names.Add(Add_Text.Text); // Adds the value
            Add_Text.Clear(); // Clears the text box
            MessageBox.Show("Value Added"); // Displays a message
        }
        /* Firstly...
        
         * We have an IF function that checks whether "names" contains the content
                of the search box, so if its a letter "a", it checks if its in our list.
         * It then creates a variable "SearchText" that we can later use that simply
                means that instead of writing the whole code we can just refer to it by our new name
         * Another variable! This one defines our Index in our list, it takes
                our previous variable and looks for it in our list and finds what
                the index number of that value is.
         * Now, since its Search on demand we essentially have two Lists (arrays) now
                that we have the name of the value we looking for in string format,
                we also have our index as integer (defined earlier in class). We need to take that data
                and add it to our display List and for that we have our function.
                Adds new Items to our list using the Items Class and also defines
                what data should be put into each column.
         * It then clears the search text box
         * and shows us that the value has been found.
         
         We then move to ELSE which is simple really...
         
            * Didn't find data
            * Clears search text box
            * Displays message that its not been found...  */
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            if (names.Contains(Search_Text.Text))  // Our If statement
            {
                var SearchText = Search_Text.Text;  // First Variable
                var FindIndex = names.IndexOf(SearchText);  // Second Variable
                List_Box.Items.Add(new Items() { Index = FindIndex, Name = SearchText});  // Adding items to display list
                Search_Text.Clear();  // Clear search text box
                MessageBox.Show("Data Found"); // Display message
            }
            else
            {
                Search_Text.Clear();
                MessageBox.Show("Not Found");
            };
        }
        /* Lastly a simple clear button for our display list.
         * Once a user searches for many values and wants to clear the display list
         * he can do it by hitting a single button.
         * 
         * This button DOES NOT delete anything from our "names" list it only
         * clears the display data meaning that the user can search for more data
         * that has been added already.  */
        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            List_Box.Items.Clear();
        }
        
        private void Add_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void Search_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
 }
[Here is how it looks, simple but you get the idea, I'm learning...][1]
  [1]: https://i.stack.imgur.com/UAqiQ.jpg
