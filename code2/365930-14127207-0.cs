    public class YourControllerAction {
        public YourControllerAction(MyDbContext context) {
             ListA = context.TableA.Where(x => x.Something).Select(x => x.ConvertSqlToBusinessObject()).ToList();
             ListB = context.TableB.Where(x => x.Something).Select(x => x.ConvertSqlToBusinessObject()).ToList();
        }
    }
