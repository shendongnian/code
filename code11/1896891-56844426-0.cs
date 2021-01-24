public Interface DaddyBaby
{
    string AS {get; set}
    string BS {get; set;}
}
You can still use a base class, it must be the first one in the list ie after the ":".
Assuming the Daddy has a base class of DaddyBase:
public class Daddy: DaddyBase, DaddyBaby
public class Baby: DaddyBaby
