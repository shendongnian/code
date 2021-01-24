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
