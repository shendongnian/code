    class CMyListCtrl : public CMFCListCtrl
    {
        // Your stuff  goes here....
       public:
        DECLARE_MESSAGE_MAP()
        afx_msg void OnLvnItemchanged(NMHDR *pNMHDR, LRESULT *pResult);
    }
