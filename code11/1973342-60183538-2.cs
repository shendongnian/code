    public class CreateEmployeeInfoTiles : MonoBehaviour
    { 
        // NOTE: Do NOT use Resources!
        // rather place your prefab in any other folder and then simply drag it in here
        // via the Inspector!
        // By using directly the correct type instead of GameObject you
        //  a) do not need the GetComponent later since Instantiate already returns the dsme type
        //  b) have more security since now you only can drag&drop a GameObject here
        //     that actually has the required component attached
        [SerializeField] private EmployeeController employeePrefab;
    
        // Start is called before the first frame update
        private void Start()
        {
            var employeeData = Employee.GenrateEmployees(6).ToArray();
          
            var j = 10;  
            for (int i = 0; i < employeeData.Length; i++)
            {
                var employee = Instantiate(employeePrefab, new Vector3((i * 10), (j * 20), 115), Quaternion.identity);
        
                employee.BindData(emp[i]);
    
                j =+ 30;
            } 
        }
    }
    
        
