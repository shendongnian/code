 language: c#
public class Form1
{
    private TreePresantation treePresantation = null;
    private void Form1_Load(object sender, EventArgs e)
    {
        AVLTree avltree = new AVLTree();
        treePresantation = new TreePresantation(avltree);
    }
    private void BtnPut_Click(object sender, EventArgs e)
    {
        if ((txtPutKey.Text == null) || (txtPutValue.Text == null))
        {
            txtMessage.Text = "Key or Value cannot be empty!";
        }
        else
        {
            treepresantation.Put(Convert.ToInt32(txtPutKey.Text), txtPutValue.Text);
        }
    }
}
