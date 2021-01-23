     private void readData() {
                ///read all the data into memory (if you can)
                string[] _data = File.ReadAllLines(inputDataFile);
                Queue<String> _lines = new Queue<string>();
                foreach (string _line in _data) {
                    _lines.Enqueue(_line.Trim()); //put it into a queue for convience
                }
                
                ///iterate through the data and extract the details based on 
                ///known record delimiters.
                while (_lines.Count > 0) {
                    Customer _customer = new Customer(
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue(),
                        _lines.Dequeue());
                    int _numberOfAccounts = _customer.getNumberAccounts();
                    for (int i = 1; i <= _numberOfAccounts; i++) {
                        Account _account = new Account(
                            _lines.Dequeue(),
                            _lines.Dequeue(),
                            _lines.Dequeue(),
                            _lines.Dequeue(),
                            _lines.Dequeue(),
                            _lines.Dequeue(),
                            _lines.Dequeue());
                        int _numberOfTransactions = _account.getAccNumTrans();
                        for (int j = 1; j <= _numberOfTransactions; j++) {
                            Transaction _transaction = new Transaction(
                                _lines.Dequeue(),
                                _lines.Dequeue(),
                                _lines.Dequeue(),
                                _lines.Dequeue(),
                                _lines.Dequeue());
                            _account.Transactions.Add(_transaction);
                        }
                        _customer.Accounts.Add(_account);
                    }
    
                    ///update the legacy part of the system.
                    bankDetails.Add(_customer);
                    foreach (Account _account in _customer.Accounts) {
                        accDetails.Add(_account);
                        foreach (Transaction _transaction in _account.Transactions) {
                            tranDetails.Add(_transaction);
                        }
                    }
                }
            }
