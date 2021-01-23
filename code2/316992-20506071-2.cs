    public class DeleteColumn : DataGridViewButtonColumn {
            public DeleteColumn() {
                this.CellTemplate = new DeleteCell();
                this.Width = 20;
                //set other options here 
            }
        }
