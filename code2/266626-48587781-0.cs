    partial class YourTableAdapter
    {
        public SqlTransaction Transaction
        {
            set
            {
                if (this.CommandCollection != null)
                {
                    for (int i = 0; i < this.CommandCollection.Length; i++)
                    {
                        this.CommandCollection[i].Connection = value.Connection;
                        this.CommandCollection[i].Transaction = value;
                    }
                }
                this.Connection = value.Connection;
                this._adapter.AplicaTransaction(value);
            }
        }
    }
