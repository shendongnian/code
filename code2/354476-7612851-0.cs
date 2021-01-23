    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    
    namespace TestBinding
    {
    	/// <summary>
    	/// Interaction logic for Window1.xaml
    	/// </summary>
    	public partial class Window1 : Window
    	{
    		public Window1()
    		{
    			InitializeComponent();		
    		}
    
    		public override void OnApplyTemplate()
    		{
    			base.OnApplyTemplate();
    			CreateTeamControls();
    			myGame[2] = "Marge";
    		}
    
    		void CreateTeamControls()
    		{
    			var panel = new StackPanel();
    			this.Content = panel;
    			int teams = myGame.TeamCount;
    
    			for (int currCol = 0; currCol < teams; currCol++)
    			{
    				TextBlock teamNameBlock = new TextBlock();
    
    				panel.Children.Add(teamNameBlock);
    
    				Binding myNameBinding = new Binding();
    				myNameBinding.Source = myGame;
    				myNameBinding.Path = new PropertyPath("[" + currCol + "]");
    				myNameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    				teamNameBlock.SetBinding(TextBlock.TextProperty, myNameBinding);
    			}
    		}
    
    		GameModel myGame = new GameModel();
    	}
    }
    
    class GameModel : INotifyPropertyChanged 
    {
    	string[] _teamNames = new string[3];
    
    	public int TeamCount { get { return _teamNames.Count(); } }
    
    	public GameModel()
    	{
    		_teamNames[0] = "Bart";
    		_teamNames[1] = "Lisa";
    		_teamNames[2] = "Homer";
    	}
    
    	public string this[int TeamName]
    	{
    		get
    		{
    			return _teamNames[TeamName];
    		}
    		set
    		{
    			if (_teamNames[TeamName] != value)
    			{
    				_teamNames[TeamName] = value;
    				OnPropertyChanged("Item[]");
    			}
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private void OnPropertyChanged(string propertyName)
    	{
    		var changedHandler = this.PropertyChanged;
    		if (changedHandler != null)
    			changedHandler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
