    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace TreeViewTest
    {
      class ViewModel
      {
        public ObservableCollection<ProjectViewModel>  ProjectViewModelCollection { get; private set; }
        public ViewModel ( )
        {
          ProjectViewModelCollection = new ObservableCollection<ProjectViewModel>() ;
          ProjectViewModelCollection.Add ( new ProjectViewModel() ) ;
          ProjectViewModelCollection.Add ( new ProjectViewModel() ) ;
        }
      }
      class ProjectViewModel
      {
        public ObservableCollection<SelectActivityViewModel>  SelectActivityViewModelCollection { get; private set; }
        public string Header { get ; } = "ProjectViewModel" ;
        public ProjectViewModel ( )
        {
          SelectActivityViewModelCollection = new ObservableCollection<SelectActivityViewModel>() ;
          SelectActivityViewModelCollection.Add ( new SelectActivityViewModel() ) ;
          SelectActivityViewModelCollection.Add ( new SelectActivityViewModel() ) ;
        }
      }
      class SelectActivityViewModel
      {
        public ObservableCollection<ToolsViewModel>  ToolsViewModelCollection  { get; private set; }
        public string Header { get ; } = "SelectActivityViewModel" ;
        public SelectActivityViewModel ( )
        {
          ToolsViewModelCollection = new ObservableCollection<ToolsViewModel>() ;
          ToolsViewModelCollection.Add ( new ToolsViewModel() ) ;
          ToolsViewModelCollection.Add ( new ToolsViewModel() ) ;
        }
      }
      class ToolsViewModel
      {
        public ObservableCollection<SheetsViewModel>    SheetsViewModelCollection    { get; private set; }
        public ObservableCollection<FeaturesViewModel>  FeaturesViewModelCollection  { get; private set; }
        public string Header { get ; } = "ToolsViewModel" ;
        public ToolsViewModel ( )
        {
          SheetsViewModelCollection = new ObservableCollection<SheetsViewModel>() ;
          SheetsViewModelCollection.Add ( new SheetsViewModel() ) ;
          SheetsViewModelCollection.Add ( new SheetsViewModel() ) ;
          FeaturesViewModelCollection = new ObservableCollection<FeaturesViewModel>() ;
          FeaturesViewModelCollection.Add ( new FeaturesViewModel() ) ;
          FeaturesViewModelCollection.Add ( new FeaturesViewModel() ) ;
        }
      }
      class SheetsViewModel
      {
        public string Header { get ; } = "SheetsViewModel" ;
      }
      class FeaturesViewModel
      {
        public ObservableCollection<UseCaseViewModel>  UseCaseViewModelCollection   { get; private set; }
        public string Header { get ; } = "FeaturesViewModel" ;
        public FeaturesViewModel ( )
        {
          UseCaseViewModelCollection = new ObservableCollection<UseCaseViewModel>() ;
          UseCaseViewModelCollection.Add ( new UseCaseViewModel() ) ;
          UseCaseViewModelCollection.Add ( new UseCaseViewModel() ) ;
        }
      }
      class UseCaseViewModel
      {
        public string Header { get ; } = "UseCaseViewModel" ;
      }
    }
