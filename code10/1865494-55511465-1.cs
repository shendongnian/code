    using System;
    public class Parameters
    {
        public string Name { get; set; }
    }
    public class DefectModel
    {
        public Parameters SelectedQualDefectParameters { get; set; }
    }
    public class ViewModel
    {
        private DefectModel _defectModel;
        public ViewModel(DefectModel defectModel)
        {
            _defectModel = defectModel;
        }
        public string ChosenQualityParameter
        {
            get => _defectModel.SelectedQualDefectParameters?.Name ?? "Не выбран параметр";
        }
    }
    class Program
    {
        static void Main()
        {
            var defectModel = new DefectModel
            {
                SelectedQualDefectParameters = new Parameters
                {
                    Name = "test"
                }
            };
            var viewModel = new ViewModel(defectModel);
            Console.WriteLine(viewModel.ChosenQualityParameter);
            defectModel.SelectedQualDefectParameters.Name = "changed";
            Console.WriteLine(viewModel.ChosenQualityParameter);
            Console.ReadKey();
        }
    }
