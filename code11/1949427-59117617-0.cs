        <?xml version="1.0" encoding="utf-8" ?>
    <ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
                 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                 x:Class="PracticeXamarinForms.Views.CalculationPage">
        <ContentPage.Content>
            <StackLayout>
                <Label x:Name ="result" 
                    VerticalOptions="CenterAndExpand" 
                    HorizontalOptions="CenterAndExpand" />
                <Button Text="Click Me" HorizontalOptions="CenterAndExpand" VerticalOptions="CenterAndExpand" Clicked="Button_Clicked"/>
            </StackLayout>
        </ContentPage.Content>
    </ContentPage>
    
    using System;
    using Xamarin.Forms;
     
    namespace PracticeXamarinForms.Views
    {
    	public partial class CalculationPage : ContentPage
    	{
    		public CalculationPage ()
    		{
    			InitializeComponent ();
            }
    
            private void Button_Clicked(object sender, EventArgs e)
            {
                result.Text = Convert.ToString(KosinosovaTeorema(1, 2, 3, 1));
            }
    
            public static double KosinosovaTeorema(double ABNadZnamenatel, int ABPodZnamenatel, double ACNadZnamenatel, int ACPodZnamenatel)
            {
                double V_Znamenatel_NadLiniq = 2 * ACNadZnamenatel * ABNadZnamenatel;
                int V_Znamenatel_PodLiniq = ACPodZnamenatel * ABPodZnamenatel;
                return V_Znamenatel_NadLiniq + V_Znamenatel_PodLiniq;
            }
        }
    }
