using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
namespace xxx
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();         
        }
       
        private void Button_Clicked(object sender, EventArgs e)
        {
           
            List<MyButton> myButtons = new List<MyButton>() { new MyButton("Sweet", MyButton_Clicked), new MyButton("Candy", MyButton_Clicked), new MyButton("Gum", MyButton_Clicked) };
            stack1.Children.Clear();
            foreach(MyButton myButton in myButtons)
            {
                stack1.Children.Add(myButton);
            }
            
        }
        private void MyButton_Clicked(object sender, EventArgs e)
        {
            var mybutton = sender as MyButton;
            var title = mybutton.Text;
            List<MyButton> myButtons = new List<MyButton>();
            if (title=="Sweet")
            {
                 myButtons = new List<MyButton>() { new MyButton("111", MyButton_Clicked), new MyButton("222", MyButton_Clicked), new MyButton("333", MyButton_Clicked) };              
            }
            else if (title== "Candy")
            {
                myButtons = new List<MyButton>() { new MyButton("444", MyButton_Clicked), new MyButton("555", MyButton_Clicked), new MyButton("666", MyButton_Clicked) };
            }
            else
            {
                myButtons = new List<MyButton>() { new MyButton("777", MyButton_Clicked), new MyButton("888", MyButton_Clicked), new MyButton("999", MyButton_Clicked) };
            }
            stack2.Children.Clear();
            foreach (MyButton myButton in myButtons)
            {
                stack2.Children.Add(myButton);
            }
        }
    }
    public class MyButton:Button
    {
        public MyButton(string title,EventHandler clicked)
        {
            this.Text = title;
            Clicked += clicked;
        }
       
    }
}
I used static data just for demo , and you can get the data from database or webservice .
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/V8rfR.gif
