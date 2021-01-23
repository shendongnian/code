    List<int> listint
    List<int> listintTwo
    return (from oa in _entity.TableOne
          join cc in _entity.TableTwo on oa.TableSix.ColumnOne equals cc.TableSix.ColumnOne
          join os in _entity.TableThree on oa.TableThree.ColumnTwo equals os.ColumnTwo
          join cs in _entity.TableTwotatus on cc.TableTwotatus.ColumnThree equals cs.ColumnThree
          join app in _entity.TableFour on cc.TableFour.ColumnFour equals app.ColumnFour
          join cl in _entity.TableFive on app.TableFive.ColumnFive equals cl.ColumnFive).ToList().
          where listint.Any(x =>x == cc.TableTwotatus.ColumnThree)
          && listintTwo.Any(x => x == os.ColumnTwo) && cc.TableSix.ColumnOne == ColumnOne 
          select new TableFive {ColumnFive = cl.ColumnFive, CompanyName = cl.CompanyName}).ToList();</pre>
